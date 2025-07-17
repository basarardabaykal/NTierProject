import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "./ui/table"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import CompanySelector from "./CompanySelector"

interface UsersTableProps {
  users: User[]
  companies: Company[]
}

export default function UsersPanel({ users, companies }: UsersTableProps) {
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
              <TableCell><CompanySelector companies={companies}></CompanySelector></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}
