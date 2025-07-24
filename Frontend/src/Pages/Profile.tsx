import { useAuth } from "../context/AuthContext"

export default function Profile() {
	const { user } = useAuth()
	console.log(user)

	if (user) {
		return (
			<div>
				<p>{user?.firstName + " " + user.lastName}</p>
				<p>{user.id}</p>
				<p>{user.email}</p>
				<p>{user.tcnumber}</p>
				<p>{user.companyId}</p>
				<p>{user.roles}</p>
			</div>
		)
	}

}