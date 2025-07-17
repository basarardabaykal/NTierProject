import UsersTable from "../components/UsersTable"
import axios from "axios"
import { useState } from "react"
import { useEffect } from "react"

export default function UsersPanel() {
    interface User {
        name: string
        email: string
        company: string
    }

    const [users, setUsers] = useState<User[]>([])

    const getUsers = async () => {
        const response = await axios.get("https://localhost:7297/api/home/getall")
        console.log(response.data.data)
        if (response.data.success) {
            const mappedUsers = response.data.data.map((user: any) => ({
                name: user.firstname + " " + user.lastname,
                email: user.email,
                company: user.company
            }))
            setUsers(mappedUsers)
        }
    }

    useEffect(() => {
        getUsers()
    }, [])


    return (
        <main className="flex min-h-screen flex-col items-center justify-center p-4">
            <h1 className="mb-6 text-3xl font-bold">User Directory</h1>
            <UsersTable users={users} />
        </main>
    )
}