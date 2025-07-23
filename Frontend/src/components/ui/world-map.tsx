"use client";

import { useInView } from "framer-motion";


import { useRef, useMemo, useCallback } from "react";
import { motion } from "motion/react";
import DottedMap from "dotted-map";
import { easeOut } from "motion"


interface MapProps {
  dots?: Array<{
    start: { lat: number; lng: number; label?: string };
    end: { lat: number; lng: number; label?: string };
  }>;
  lineColor?: string;
}

export default function WorldMap({
  dots = [],
  lineColor = "#0ea5e9",
}: MapProps) {
  const svgRef = useRef<SVGSVGElement>(null);

  // Memoize the map instance to prevent recreation on every render
  const map = useMemo(() => new DottedMap({ height: 60, grid: "diagonal" }), []);

  // Move isDark check to useMemo to prevent repeated DOM queries
  const isDark = useMemo(() =>
    document.documentElement.classList.contains("dark"), []
  );

  const svgMap = useMemo(() => {
    return map.getSVG({
      radius: 0.22,
      color: isDark ? "#FFFFFF40" : "#00000040",
      shape: "circle",
      backgroundColor: isDark ? "black" : "white",
    });
  }, [map, isDark]);

  // Memoize utility functions
  const projectPoint = useCallback((lat: number, lng: number) => {
    const x = (lng + 180) * (800 / 360);
    const y = (90 - lat) * (400 / 180);
    return { x, y };
  }, []);

  const createCurvedPath = useCallback((
    start: { x: number; y: number },
    end: { x: number; y: number }
  ) => {
    const midX = (start.x + end.x) / 2;
    const midY = Math.min(start.y, end.y) - 50;
    return `M ${start.x} ${start.y} Q ${midX} ${midY} ${end.x} ${end.y}`;
  }, []);

  // Memoize projected points to avoid recalculation
  const projectedDots = useMemo(() =>
    dots.map(dot => ({
      start: projectPoint(dot.start.lat, dot.start.lng),
      end: projectPoint(dot.end.lat, dot.end.lng),
      originalDot: dot
    })), [dots, projectPoint]
  );

  // Memoize paths to avoid recalculation
  const paths = useMemo(() =>
    projectedDots.map(({ start, end }) => createCurvedPath(start, end)),
    [projectedDots, createCurvedPath]
  );

  // Memoize animation variants
  const pathVariants = useMemo(() => ({
    initial: { pathLength: 0 },
    animate: { pathLength: 1 }
  }), []);

  const getAnimationTransition = useCallback((index: number) => ({
    duration: 1,
    delay: 0.5 * index,
    ease: easeOut
  }), []);

  // Memoize circle animation elements
  const CircleWithAnimation = useCallback(({ cx, cy, color }: {
    cx: number;
    cy: number;
    color: string;
  }) => (
    <g>
      <circle cx={cx} cy={cy} r="2" fill={color} />
      <circle cx={cx} cy={cy} r="2" fill={color} opacity="0.5">
        <animate
          attributeName="r"
          from="2"
          to="8"
          dur="1.5s"
          begin="0s"
          repeatCount="indefinite"
        />
        <animate
          attributeName="opacity"
          from="0.5"
          to="0"
          dur="1.5s"
          begin="0s"
          repeatCount="indefinite"
        />
      </circle>
    </g>
  ), []);

  const containerRef = useRef(null);
  const isInView = useInView(containerRef, { margin: "-100px" });

  return (
    <div
      ref={containerRef}
      className="w-full aspect-[2/1] dark:bg-black bg-white rounded-lg relative font-sans"
    >
      <img
        src={`data:image/svg+xml;utf8,${encodeURIComponent(svgMap)}`}
        className="h-full w-full [mask-image:linear-gradient(to_bottom,transparent,white_10%,white_90%,transparent)] pointer-events-none select-none"
        alt="world map"
        height="495"
        width="1056"
        draggable={false}
      />

      <svg
        ref={svgRef}
        viewBox="0 0 800 400"
        className="w-full h-full absolute inset-0 pointer-events-none select-none"
      >
        <defs>
          <linearGradient id="path-gradient" x1="0%" y1="0%" x2="100%" y2="0%">
            <stop offset="0%" stopColor="white" stopOpacity="0" />
            <stop offset="5%" stopColor={lineColor} stopOpacity="1" />
            <stop offset="95%" stopColor={lineColor} stopOpacity="1" />
            <stop offset="100%" stopColor="white" stopOpacity="0" />
          </linearGradient>
        </defs>

        {/* Render animated paths */}
        {paths.map((path, i) => (
          <motion.path
            key={`path-${i}`}
            d={path}
            fill="none"
            stroke="url(#path-gradient)"
            strokeWidth="1"
            variants={pathVariants}
            initial="initial"
            animate={isInView ? "animate" : "initial"}
            transition={getAnimationTransition(i)}
          />
        ))}

        {/* Render animated circles */}
        {projectedDots.map(({ start, end }, i) => (
          <g key={`circles-${i}`}>
            <CircleWithAnimation cx={start.x} cy={start.y} color={lineColor} />
            <CircleWithAnimation cx={end.x} cy={end.y} color={lineColor} />
          </g>
        ))}
      </svg>
    </div>
  );
}