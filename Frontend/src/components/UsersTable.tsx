import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "./ui/table"
import type { User } from "../interfaces/User"
import type { Company } from "../interfaces/Company"
import type { Branch } from "../interfaces/Branch"
import CompanySelector from "./CompanySelector"
import BranchSelector from "./BranchSelector"
import { useState, useEffect, useMemo } from "react"
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
  const [userCompanies, setUserCompanies] = useState<Record<string, string>>({})
  const { isAdmin } = useAuth()

  // Initialize user companies state
  useEffect(() => {
    const initialCompanies = users.reduce((acc, user) => {
      acc[user.id] = user.companyId
      return acc
    }, {} as Record<string, string>)
    setUserCompanies(initialCompanies)
  }, [users])

  useEffect(() => {
    const timer = setTimeout(() => setAnimateRows(true), 100)
    return () => clearTimeout(timer)
  }, [])

  const handleSaveCompany = async (userId: string, newCompanyId: string) => {
    setSavingUserId(userId)
    setSavingType('company')
    try {
      await onUpdateUserCompany(userId, newCompanyId)
      setUserCompanies(prev => ({
        ...prev,
        [userId]: newCompanyId
      }))
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

  const getFilteredBranches = useMemo(() => {
    return (userId: string) => {
      const currentCompanyId = userCompanies[userId] || users.find(u => u.id === userId)?.companyId
      return branches.filter(branch => String(branch.companyId) === String(currentCompanyId))
    }
  }, [branches, userCompanies, users])

  return (
    <div className="overflow-hidden rounded-2xl border border-gray-200/60 dark:border-gray-700/60 shadow-lg dark:shadow-2xl w-3/4 bg-white dark:bg-gray-900/95 backdrop-blur-sm 
    transition-all duration-500 hover:shadow-xl dark:hover:shadow-3xl hover:border-gray-300/60 dark:hover:border-gray-600/80 dark:hover:shadow-blue-500/10">
      <div className="overflow-auto max-h-96 scrollbar-hide">
        <Table>
          <TableHeader className="sticky top-0 z-10 bg-gradient-to-r from-slate-50 to-gray-300 dark:from-gray-800/95 dark:to-gray-950/95 border-b border-gray-200/60 dark:border-gray-700/60 backdrop-blur-md">
            <TableRow className="hover:bg-transparent border-none">
              <TableHead className="py-6 px-8 text-sm font-semibold text-gray-700 dark:text-gray-200 tracking-wide">
                Name
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold dark:text-gray-200 tracking-wide">
                Email
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold dark:text-gray-200 tracking-wide">
                TC Number
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold dark:text-gray-200 tracking-wide">
                Company
              </TableHead>
              <TableHead className="py-6 px-8 text-sm font-semibold dark:text-gray-200 tracking-wide">
                Branch
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {users.map((user, index) => {
              const currentCompanyId = userCompanies[user.id] || user.companyId
              const filteredBranches = getFilteredBranches(user.id)

              return (
                <TableRow
                  key={user.id || index}
                  className={`
                    group border-b border-gray-100/60 dark:border-gray-700/40 last:border-none
                    hover:bg-gradient-to-r hover:from-blue-50/30 hover:to-indigo-50/30 
                    dark:hover:from-gray-800/50 dark:hover:to-gray-750/50
                    transition-all duration-300 ease-out
                    transform
                    ${animateRows
                      ? 'translate-y-0 opacity-100'
                      : 'translate-y-4 opacity-0'
                    }
                    ${savingUserId === user.id
                      ? 'bg-gradient-to-r from-amber-50/50 to-orange-50/50 dark:from-amber-900/30 dark:to-orange-900/30 scale-[1.01] dark:shadow-lg dark:shadow-amber-500/10'
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
                      <div className="w-8 h-8 rounded-full bg-gradient-to-br from-blue-400 to-purple-500 dark:from-blue-500 dark:to-purple-600 flex items-center justify-center text-white text-sm font-medium shadow-sm dark:shadow-lg dark:shadow-blue-500/20 transition-transform duration-300 group-hover:scale-110 dark:group-hover:shadow-xl dark:group-hover:shadow-blue-500/30">
                        {(user.firstName?.[0] || '') + (user.lastName?.[0] || '')}
                      </div>
                      <span className="font-medium text-gray-900 dark:text-gray-100 transition-colors duration-300 group-hover:text-blue-700 dark:group-hover:text-blue-300">
                        {user.firstName + ' ' + user.lastName}
                      </span>
                    </div>
                  </TableCell>

                  <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                    <span className="inline-flex items-center px-4 py-2 text-sm font-medium text-gray-700 dark:text-gray-300 bg-gray-200/70 dark:bg-gray-800/70 rounded-full transition-all duration-300 
                    group-hover:bg-gray-200/70 dark:group-hover:bg-gray-700/80 group-hover:text-gray-900 dark:group-hover:text-gray-200 hover:text-lg border border-transparent dark:border-gray-700/50 dark:group-hover:border-gray-600/60 dark:group-hover:shadow-md">
                      {user.email}
                    </span>
                  </TableCell>

                  <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                    <div className="inline-flex items-center px-4 py-2 text-sm font-medium text-gray-700 dark:text-gray-300 bg-gray-200/70 dark:bg-gray-800/70 rounded-full transition-all duration-300 
                    group-hover:bg-gray-200/70 dark:group-hover:bg-gray-700/80 group-hover:text-gray-900 dark:group-hover:text-gray-200 hover:text-lg border border-transparent dark:border-gray-700/50 dark:group-hover:border-gray-600/60 dark:group-hover:shadow-md">
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
                            defaultCompanyId={currentCompanyId}
                            onSave={(newCompanyId) => handleSaveCompany(user.id, newCompanyId)}
                            isSaving={savingUserId === user.id && savingType === 'company'}
                          />
                        </div>
                      ) : (
                        <div className="inline-flex items-center px-4 py-2 text-sm hover:text-lg font-medium dark:text-blue-300 bg-blue-900/40 rounded-lg transition-all duration-300 group-hover:bg-blue-800/50 group-hover:text-blue-200 group-hover:shadow-md group-hover:shadow-blue-500/20 border border-blue-800/50 group-hover:border-blue-700/60">
                          {companies?.find(company => company.id === currentCompanyId)?.name || 'No Company'}
                        </div>
                      )}
                    </div>
                  </TableCell>

                  <TableCell className="py-5 px-8 transition-all duration-300 group-hover:px-10">
                    <div className="transform transition-all duration-300 group-hover:scale-105">
                      {isAdmin() ? (
                        <div className={`transition-all duration-500 ${savingUserId === user.id && savingType === 'branch' ? 'animate-pulse' : ''
                          }`}>
                          <BranchSelector
                            branches={filteredBranches}
                            defaultBranchId={user.branchId}
                            onSave={(newBranchId: string) => handleSaveBranch(user.id, newBranchId)}
                            isSaving={savingUserId === user.id && savingType === 'branch'}
                          />
                        </div>
                      ) : (
                        <div className="inline-flex items-center px-4 py-2 text-sm hover:text-lg font-medium dark:text-emerald-300 bg-emerald-900/40 rounded-lg transition-all duration-300 group-hover:bg-emerald-800/50 group-hover:text-emerald-200 group-hover:shadow-md group-hover:shadow-emerald-500/20 border border-emerald-800/50 group-hover:border-emerald-700/60">
                          {branches?.find(branch => branch.id === user.branchId)?.name || 'No Branch'}
                        </div>
                      )}
                    </div>
                  </TableCell>
                </TableRow>
              )
            })}
          </TableBody>
        </Table>
      </div>
      <div className="h-2 bg-gradient-to-r from-blue-500/20 via-purple-500/20 to-pink-500/20"></div>
    </div>
  )
}