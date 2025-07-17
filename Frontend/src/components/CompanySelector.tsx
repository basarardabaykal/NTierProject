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
}

export default function CompanySelector({ companies }: CompanySelectorProps) {
  return (
    <Select>
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder="Company" />
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