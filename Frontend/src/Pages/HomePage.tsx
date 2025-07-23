import { useEffect, useRef, useState } from "react"
import { useSmoothScroll } from "../components/SmoothScroll";
import securifyLogo from "../assets/securify.avif"
import image1 from "../assets/image1.png"
import WorldMap from "../components/ui/world-map"
import { GlareCard } from "../components/ui/glare-card"
import { PointerHighlight } from "../components/ui/pointer-highlight"

export default function HomePage() {
	const [scrollY, setScrollY] = useState(0)
	const stickyRef = useRef<HTMLDivElement>(null)
	const containerRef = useRef<HTMLDivElement>(null)

	useEffect(() => {
		const onScroll = () => {
			setScrollY(window.scrollY)
		}

		window.addEventListener("scroll", onScroll)
		return () => window.removeEventListener("scroll", onScroll)
	}, [])

	useSmoothScroll()

	return (
		<div ref={containerRef} className=" bg-gradient-to-tr from-indigo-200 via-purple-200 to-pink-200 py-4 text-neutral-900">
			<div>
				<img src={image1} className="w-7/12 ml-4 rounded-2xl" alt="" />
			</div>

			<div className="flex flex-row">
				<div
					ref={stickyRef}
					className="w-2/5 p-4 h-screen fixed top-0 right-0
					flex flex-col justify-center"
					style={{
						transform: `translateY(${Math.min(0, 650 - scrollY)}px)`
					}}
				>
					<p className="text-6xl font-bold mb-16">Manage Your Employees, Increase Your Productivity!</p>
					<img src={securifyLogo} className="filter invert" alt="" />
				</div>
			</div>

			<div className="w-4/5 mx-auto mt-80">
				<p className="text-6xl mb-28">Don't Let Distances Affect Your Workflow</p>
				<div className="w-4/5 mx-auto">
					<WorldMap lineColor="blue"
						dots={[
							{
								start: { lat: 26, lng: 34, label: "Start Point" },
								end: { lat: 5, lng: 55, label: "End Point" },
							},
							{
								start: { lat: 30, lng: -80 },
								end: { lat: 40, lng: 10 },
							},
							{
								start: { lat: 25, lng: 140 },
								end: { lat: 20, lng: 100 },
							},
							{
								start: { lat: -40, lng: 25 },
								end: { lat: -50, lng: 145 },
							},
						]}
					></WorldMap>
				</div>

			</div >

			<div className="mt-80 max-w-5/6 mx-auto pb-80">
				<p className="text-7xl">Smarter Employee Management Starts Here</p>
				<p className="text-4xl mt-40">Ditch the spreadsheets. Save time, stay organized, and manage your team like a pro with our all-in-one employee management platform.</p>

				<div className="flex flex-row justify-evenly mt-80">
					<GlareCard>
						<p>Simple</p>
					</GlareCard>
					<GlareCard>
						<p>Fast</p>
					</GlareCard>
					<GlareCard>
						<p>Powerful</p>
					</GlareCard>
				</div>
				<div className="text-5xl mt-60 flex flex-row justify-center">
					<PointerHighlight><a href="panel">Try it</a></PointerHighlight>
					<p className="ml-6">for free and see the difference.</p>
				</div>
			</div>

		</div >
	)
}