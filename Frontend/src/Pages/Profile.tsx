import { useAuth } from "../context/AuthContext"

export default function Profile() {
    const { user } = useAuth()

    return (
        <div>
            <p>{user?.name}</p>
        </div>
    )
}