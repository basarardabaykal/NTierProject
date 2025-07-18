import { useState } from "react";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../components/ui/select"
import { Button } from "./ui/button";
import type { Company } from "../interfaces/Company"

interface CompanySelectorProps {
  companies: Company[]
  defaultCompanyId?: string
  onSave: (newCompanyId: string) => void
  isSaving?: boolean
}

export default function CompanySelector({ companies, defaultCompanyId, onSave, isSaving }: CompanySelectorProps) {
  const [selectedCompanyId, setSelectedCompanyId] = useState<string>(defaultCompanyId || "")
  const [hasChanged, setHasChanged] = useState<boolean>(false)

  const handleValueChange = (companyName: string) => {
    const selectedCompany = companies.find(company => company.name === companyName)
    if (selectedCompany) {
      setSelectedCompanyId(selectedCompany.id)
      setHasChanged(selectedCompany.id !== defaultCompanyId)
    }
  }

  const handleSave = () => {
    if (hasChanged && selectedCompanyId) {
      onSave(selectedCompanyId)
      setHasChanged(false)
    }
  }

  const selectedCompany = companies.find(company => company.id === selectedCompanyId)
  const displayValue = selectedCompany ? selectedCompany.name : "Unassigned"

  return (
    <div>
      <Select value={displayValue} onValueChange={handleValueChange}>
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
      {hasChanged && (
        <Button
          onClick={handleSave}
          disabled={isSaving}
          size="sm"
          className="px-3"
        >
          {isSaving ? "Saving..." : "Save"}
        </Button>
      )}
    </div>
  )
}