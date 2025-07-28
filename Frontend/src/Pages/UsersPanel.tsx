import UsersTable from "../components/UsersTable"
import axios from "axios"
import { useNavigate } from "react-router-dom"
import { useState } from "react"
import { useEffect } from "react"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import type { Branch } from "../interfaces/Branch"
import { userService } from "../services/userService"
import { companyService } from "../services/companyService"
import { branchService } from "../services/branchService"

export default function UsersPanel() {
  const navigate = useNavigate()
  const [users, setUsers] = useState<User[]>([])
  const [companies, setCompanies] = useState<Company[]>([])
  const [branches, setBranches] = useState<Branch[]>([])

  const getUsers = async () => {
    try {
      const token = localStorage.getItem("token")
      if (!token) {
        navigate("/login")
        return
      }

      const response = await userService.getAll(token)

      if (response.data.success) {
        const mappedUsers = response.data.data.map((user: any) => ({
          id: user.id,
          firstName: user.firstname,
          lastName: user.lastname,
          email: user.email,
          tcnumber: user.tcnumber,
          companyId: user.companyId
        }))
        setUsers(mappedUsers)
      }
    } catch (error) {
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
        return
      }

      const response = await companyService.getAll(token)

      if (response.data.success) {
        const mappedCompanies = response.data.data.map((company: any) => ({
          name: company.name,
          id: company.id,
        }))
        setCompanies(mappedCompanies)
      }

    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 401) {
        navigate("/login")
      }
    }
  }

  const getBranches = async () => {
    try {
      const token = localStorage.getItem("token")
      if (!token) {
        navigate("/login")
        return
      }

      const response = await branchService.getAll(token)

      if (response.data.success) {
        const mappedBranches = response.data.data.map((branch: any) => ({
          name: branch.name,
          id: branch.id,
        }))
        setBranches(mappedBranches)
      }

      console.log(response.data)

    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 401) {
        navigate("/login")
      }
    }
  }

  const updateUserCompany = async (userId: string, companyId: string) => {
    try {
      const token = localStorage.getItem("token")
      if (!token) {
        navigate("/login")
        return
      }

      const response = await userService.updateCompany(token, userId, companyId)

      if (response.data.success) {
        setUsers(prevUsers =>
          prevUsers.map(user =>
            user.id === userId
              ? { ...user, companyId: companyId }
              : user
          )
        )
      } else {
      }
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 401) {
        navigate("/login")
      }
    }
  }

  useEffect(() => {
    getCompanies()
    getUsers()
    getBranches()
  }, [])


  return (
    <div className="flex min-h-screen flex-col items-center justify-center p-4 w-full">
      <p className="mb-8 text-4xl font-extrabold tracking-tight text-gray-800 dark:text-white">Users Table</p>
      <UsersTable users={users} companies={companies} onUpdateUserCompany={updateUserCompany} />
    </div>
  )
}