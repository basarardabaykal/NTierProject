import { useState } from "react";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../components/ui/select"
import type { Company } from "../interfaces/Company"

interface CompanySelectorProps {
  companies: Company[]
  defaultCompanyId?: string
}

export default function CompanySelector({ companies, defaultCompanyId }: CompanySelectorProps) {
  const defaultCompany = companies.find(company => company.id === defaultCompanyId)
  const defaultValue = defaultCompany ? defaultCompany.name : "Unassigned"

  return (
    <Select defaultValue={defaultValue}>
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder={"Company"} />
      </SelectTrigger>
      <SelectContent>
        {companies.map((company, index) => (
          <SelectItem key={index} value={company.name}>
            {company.name}
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  )
}