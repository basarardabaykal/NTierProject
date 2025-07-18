import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "./ui/table"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import CompanySelector from "./CompanySelector"
import { useState } from "react"

interface UsersTableProps {
  users: User[]
  companies: Company[]
  onUpdateUserCompany: (userId: string, companyId: string) => Promise<void>
}

export default function UsersTable({ users, companies, onUpdateUserCompany }: UsersTableProps) {
  const [savingUserId, setSavingUserId] = useState<string | null>(null)

  const handleSave = async (userId: string, newCompanyId: string) => {
    setSavingUserId(userId)
    try {
      await onUpdateUserCompany(userId, newCompanyId)
    } finally {
      setSavingUserId(null)
    }
  }

  return (
    <div className="w-full overflow-auto rounded-md border">
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Name</TableHead>
            <TableHead>Email</TableHead>
            <TableHead>Tc Number</TableHead>
            <TableHead>Company</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {users.map((user, index) => (
            <TableRow key={index}>
              <TableCell>{user.name}</TableCell>
              <TableCell className="font-medium">{user.email}</TableCell>
              <TableCell>{user.tcnumber}</TableCell>
              <TableCell>
                <CompanySelector
                  companies={companies}
                  defaultCompanyId={user.companyId}
                  onSave={(newCompanyId) => handleSave(user.id, newCompanyId)}
                  isSaving={savingUserId == user.id}
                />
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}
