import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "./ui/table"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import type { Branch } from "../interfaces/Branch"
import CompanySelector from "./CompanySelector"
import BranchSelector from "./BranchSelector"
import { useState, useEffect } from "react"
import { useAuth } from "../context/AuthContext"

interface UsersTableProps {
  users: User[]
  companies: Company[]
  branches: Branch[]
  onUpdateUserCompany: (userId: string, companyId: string) => Promise<void>
  onUpdateUserBranch: (userId: string, branchId: string) => Promise<void>
}

export default function UsersTable({
  users,
  companies,
  branches,
  onUpdateUserCompany,
  onUpdateUserBranch
}: UsersTableProps) {
  const [savingUserId, setSavingUserId] = useState<string | null>(null)
  const [savingType, setSavingType] = useState<'company' | 'branch' | null>(null)
  const [animateRows, setAnimateRows] = useState(false)
  const { isAdmin } = useAuth()

  useEffect(() => {
    const timer = setTimeout(() => setAnimateRows(true), 100)
    return () => clearTimeout(timer)
  }, [])

  const handleSaveCompany = async (userId: string, newCompanyId: string) => {
    setSavingUserId(userId)
    setSavingType('company')
    try {
      await onUpdateUserCompany(userId, newCompanyId)
    } finally {
      setSavingUserId(null)
      setSavingType(null)
    }
  }

  const handleSaveBranch = async (userId: string, newBranchId: string) => {
    setSavingUserId(userId)
    setSavingType('branch')
    try {
      await onUpdateUserBranch(userId, newBranchId)
    } finally {
      setSavingUserId(null)
      setSavingType(null)
    }
  }

  return (
    <div className="overflow-hidden rounded-2xl border border-gray-200/60 shadow-lg w-3/4 bg-white backdrop-blur-sm transition-all duration-500 hover:shadow-xl hover:border-gray-300/60">
      <div className="overflow-auto max-h-96">
        <Table>
          <TableHeader className="sticky top-0 z-10 bg-gradient-to-r from-slate-50 to-gray-50 border-b border-gray-200/60">
            <TableRow className="hover:bg-transparent border-none">
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 tracking-wide">
                Name
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 tracking-wide">
                Email
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 tracking-wide">
                TC Number
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 tracking-wide">
                Company
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 tracking-wide">
                Branch
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {users.map((user, index) => (
              <TableRow
                key={user.id || index}
                className={`
                  group border-b border-gray-100/60 last:border-none
                  hover:bg-gradient-to-r hover:from-blue-50/30 hover:to-indigo-50/30
                  transition-all duration-300 ease-out
                  transform
                  ${animateRows
                    ? 'translate-y-0 opacity-100'
                    : 'translate-y-4 opacity-0'
                  }
                  ${savingUserId === user.id
                    ? 'bg-gradient-to-r from-amber-50/50 to-orange-50/50 scale-[1.01]'
                    : ''
                  }
                `}
                style={{
                  transitionDelay: `${index * 50}ms`,
                  animationDelay: `${index * 50}ms`
                }}
              >
                <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                  <div className="flex items-center space-x-3">
                    <div className="w-8 h-8 rounded-full bg-gradient-to-br from-blue-400 to-purple-500 flex items-center justify-center text-white text-sm font-medium shadow-sm transition-transform duration-300 group-hover:scale-110">
                      {(user.firstName?.[0] || '') + (user.lastName?.[0] || '')}
                    </div>
                    <span className="font-medium text-gray-900 transition-colors duration-300 group-hover:text-blue-700">
                      {user.firstName + ' ' + user.lastName}
                    </span>
                  </div>
                </TableCell>

                <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                  <span className="inline-flex items-center px-4 py-2 text-sm font-medium text-gray-700 bg-gray-100/70 rounded-full transition-all duration-300 
                  group-hover:bg-gray-200/70 group-hover:text-gray-900 hover:text-lg">
                    {user.email}
                  </span>
                </TableCell>

                <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                  <div className="inline-flex items-center px-4 py-2 text-sm font-medium text-gray-700 bg-gray-100/70 rounded-full transition-all duration-300 
                  group-hover:bg-gray-200/70 group-hover:text-gray-900 hover:text-lg">
                    {user.tcnumber}
                  </div>
                </TableCell>

                <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                  <div className="transform transition-all duration-300 group-hover:scale-105">
                    {isAdmin() ? (
                      <div className={`transition-all duration-500 ${savingUserId === user.id && savingType === 'company' ? 'animate-pulse' : ''
                        }`}>
                        <CompanySelector
                          companies={companies}
                          defaultCompanyId={user.companyId}
                          onSave={(newCompanyId) => handleSaveCompany(user.id, newCompanyId)}
                          isSaving={savingUserId === user.id && savingType === 'company'}
                        />
                      </div>
                    ) : (
                      <div className="inline-flex items-center px-4 py-2 text-sm hover:text-lg font-medium text-blue-700 bg-blue-50/70 rounded-lg transition-all duration-300 group-hover:bg-blue-100/70 group-hover:text-blue-800 group-hover:shadow-sm">
                        {companies?.find(company => company.id === user.companyId)?.name || 'No Company'}
                      </div>
                    )}
                  </div>
                </TableCell>
                <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                  <div className="transform transition-all duration-300 group-hover:scale-105">
                    {isAdmin() ? (
                      <div className={`transition-all duration-500 ${savingUserId === user.id && savingType === 'branch' ? 'animate-pulse' : ''
                        }`}>
                        {
                          (() => {
                            const filteredBranches = branches.filter(branch => String(branch.companyId) === String(user.companyId));
                            return (
                              <BranchSelector
                                branches={filteredBranches}
                                defaultBranchId={user.branchId}
                                onSave={(newBranchId: string) => handleSaveBranch(user.id, newBranchId)}
                                isSaving={savingUserId === user.id && savingType === 'branch'}
                              />
                            )
                          })()
                        }
                      </div>
                    ) : (
                      <div className="inline-flex items-center px-4 py-2 text-sm hover:text-lg font-medium text-green-700 bg-green-50/70 rounded-lg transition-all duration-300 group-hover:bg-green-100/70 group-hover:text-green-800 group-hover:shadow-sm">
                        {branches?.find(branch => branch.id === user.branchId)?.name || 'No Branch'}
                      </div>
                    )}
                  </div>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
      <div className="h-2 bg-gradient-to-r from-blue-500/10 via-purple-500/10 to-pink-500/10"></div>
    </div>
  )
}