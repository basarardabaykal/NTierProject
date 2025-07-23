// useSmoothScroll.ts
import { useEffect } from "react";
import Lenis from "@studio-freight/lenis";

export const useSmoothScroll = () => {
    useEffect(() => {
        const lenis = new Lenis({
            lerp: 0.05, // lower = more slippery
            duration: 1.2, // controls scroll animation duration
            easing: (t) => Math.min(1, 1.001 - Math.pow(2, -10 * t)), // optional: custom easing function
        });

        function raf(time: number) {
            lenis.raf(time);
            requestAnimationFrame(raf);
        }

        requestAnimationFrame(raf);

        return () => {
            lenis.destroy();
        };
    }, []);
};
