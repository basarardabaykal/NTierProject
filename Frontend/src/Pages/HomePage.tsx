import { useEffect, useRef, useState } from "react"
import securifyLogo from "../assets/securify.avif"
import image1 from "../assets/image1.png"

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

	return (
		<div ref={containerRef} className=" bg-gradient-to-tr from-pink-600 via-blue-700 to-purple-600 py-4 text-white">
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
					<p className="text-6xl font-bold mb-8">Manage Your Employees, Increase Your Productivity!</p>
					<img src={securifyLogo} alt="" />
				</div>
			</div>

			<div className="mt-80 max-w-5/6 mx-auto pb-40">
				<p className="text-7xl">Smarter Employee Management Starts Here</p>
				<p className="text-4xl mt-40">Ditch the spreadsheets. Save time, stay organized, and manage your team like a pro with our all-in-one employee management platform.</p>

				<p className="text-5xl mt-40">Simple. Fast. Powerful.
					→ Try it free and see the difference.</p>
			</div>
		</div>
	)
}