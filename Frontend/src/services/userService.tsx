import { api } from "./api"
import { toast } from "react-hot-toast"

const CONTROLLER_NAME = "home"

export const userService = {
  async getAll(token: string) {
    const response = await api.get(`/${CONTROLLER_NAME}/getall`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    if (!response.data.success) {
      toast.error("An unexpected error occured.");
    }
    return response
  },

  async updateCompany(token: string, userId: string, companyId: string) {
    const response = await api.patch(`/${CONTROLLER_NAME}/updatecompany`, {
      id: userId,
      firstname: "placeholder",
      lastname: "placeholder",
      tcnumber: "11111111111",
      email: "placeholder",
      branchId: null,
      companyId: companyId,
      roles: [
        "placeholder"
      ]
    },
      {
        headers: { Authorization: `Bearer ${token}` },
      })
    if (!response.data.success) {
      toast.error("An unexpected error occured.");
    }
    return response
  },

  async updateBranch(token: string, userId: string, branchId: string) {
    const response = await api.patch(`/${CONTROLLER_NAME}/updatebranch`, {
      id: userId,
      firstname: "placeholder",
      lastname: "placeholder",
      tcnumber: "11111111111",
      email: "placeholder",
      branchId: branchId,
      companyId: null,
      roles: [
        "placeholder"
      ]
    },
      {
        headers: { Authorization: `Bearer ${token}` },
      })
    if (!response.data.success) {
      toast.error("An unexpected error occured.");
    }
    return response
  }
}