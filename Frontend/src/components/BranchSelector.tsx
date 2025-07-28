import { useEffect, useState } from "react";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../components/ui/select"
import { Button } from "./ui/button";
import type { Branch } from "../interfaces/Branch"

interface BranchSelectorProps {
  branches: Branch[]
  defaultBranchId?: string
  onSave: (newBranchId: string) => void
  isSaving?: boolean
}

export default function BranchSelector({ branches, defaultBranchId, onSave, isSaving }: BranchSelectorProps) {
  const [selectedBranchId, setSelectedBranchId] = useState<string>(defaultBranchId || "")
  const [hasChanged, setHasChanged] = useState<boolean>(false)

  const handleValueChange = (BranchName: string) => {
    const selectedBranch = branches.find(Branch => Branch.name === BranchName)
    if (selectedBranch) {
      setSelectedBranchId(selectedBranch.id)
      setHasChanged(selectedBranch.id !== defaultBranchId)
    }
  }

  const handleSave = () => {
    if (hasChanged && selectedBranchId) {
      onSave(selectedBranchId)
      setHasChanged(false)
    }
  }

  const selectedBranch = branches.find(Branch => Branch.id === selectedBranchId)
  const displayValue = selectedBranch ? selectedBranch.name : "Unassigned"

  return (
    <div className="flex flex-row justify-center">
      <Select value={displayValue} onValueChange={handleValueChange}>
        <SelectTrigger className="w-[180px]">
          <SelectValue placeholder={"Branch"} />
        </SelectTrigger>
        <SelectContent>
          {branches.map((Branch, index) => (
            <SelectItem key={index} value={Branch.name}>
              {Branch.name}
            </SelectItem>
          ))}
        </SelectContent>
      </Select>
      {hasChanged && (
        <Button
          onClick={handleSave}
          disabled={isSaving}
          size="sm"
          className="px-3 ml-2"
        >
          {isSaving ? "Saving..." : "Save"}
        </Button>
      )}
    </div>
  )
}