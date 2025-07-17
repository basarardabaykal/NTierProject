import UsersTable from "../components/UsersTable"
import axios from "axios"
import { useNavigate } from "react-router-dom"
import { useState } from "react"
import { useEffect } from "react"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"

export default function UsersPanel() {
    const navigate = useNavigate()
    const [users, setUsers] = useState<User[]>([])
    const [companies, setCompanies] = useState<Company[]>([])

    const getUsers = async () => {
        try {
            const token = localStorage.getItem("token")
            if (!token) {
                navigate("/login")
            }
            const response = await axios.get("https://localhost:7297/api/home/getall", {
                headers: { 'Authorization': `Bearer ${token}` }
            })

            if (response.data.success) {
                const mappedUsers = response.data.data.map((user: any) => ({
                    name: user.firstname + " " + user.lastname,
                    email: user.email,
                    tcnumber: user.tcnumber,
                    company: user.company
                }))
                setUsers(mappedUsers)
            }
        } catch (error) {
            console.log(error)
            if (axios.isAxiosError(error) && error.response?.status === 401) {
                navigate("/login")
            }
        }
    }

    const getCompanies = async () => {
        try {
            const token = localStorage.getItem("token")
            if (!token) {
                navigate("/login")
            }

            const response = await axios.get("https://localhost:7297/api/company/getall", {
                headers: { 'Authorization': `Bearer ${token}` }
            })

            if (response.data.success) {
                const mappedCompanies = response.data.data.map((company: any) => ({
                    name: company.name
                }))
                setCompanies(mappedCompanies)
            }

        } catch (error) {
            console.log(error)
            if (axios.isAxiosError(error) && error.response?.status === 401) {
                navigate("/login")
            }
        }
    }

    useEffect(() => {
        getUsers()
        getCompanies()
    }, [])


    return (
        <main className="flex min-h-screen flex-col items-center justify-center p-4">
            <h1 className="mb-6 text-3xl font-bold">User Directory</h1>
            <UsersTable users={users} />
        </main>
    )
}