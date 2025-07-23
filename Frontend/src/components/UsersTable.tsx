import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "./ui/table"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import CompanySelector from "./CompanySelector"
import { useState, useEffect } from "react"
import { useAuth } from "../context/AuthContext"

interface UsersTableProps {
  users: User[]
  companies: Company[]
  onUpdateUserCompany: (userId: string, companyId: string) => Promise<void>
}

export default function UsersTable({ users, companies, onUpdateUserCompany }: UsersTableProps) {
  const [savingUserId, setSavingUserId] = useState<string | null>(null)
  const { isAdmin } = useAuth()

  const handleSave = async (userId: string, newCompanyId: string) => {
    setSavingUserId(userId)
    try {
      await onUpdateUserCompany(userId, newCompanyId)
    } finally {
      setSavingUserId(null)
    }
  }

  return (
    <div className="overflow-auto rounded-xl border shadow-sm w-3/4 bg-white">
      <Table>
        <TableHeader>
          <TableRow >
            <TableHead>Name</TableHead>
            <TableHead>Email</TableHead>
            <TableHead>Tc Number</TableHead>
            <TableHead>Company</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {users.map((user, index) => (
            <TableRow key={index}>
              <TableCell className="py-4 px-6">{user.name}</TableCell>
              <TableCell className="py-4 px-6 font-medium">{user.email}</TableCell>
              <TableCell className="py-4 px-6">{user.tcnumber}</TableCell>
              <TableCell>
                {isAdmin() ? (
                  <CompanySelector
                    companies={companies}
                    defaultCompanyId={user.companyId}
                    onSave={(newCompanyId) => handleSave(user.id, newCompanyId)}
                    isSaving={savingUserId == user.id}
                  />
                ) : (
                  <p>{companies.find(company => company.id == user.companyId)?.name}</p>
                )}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}
