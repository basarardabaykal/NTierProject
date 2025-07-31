import { api } from "./api";
import { toast } from "react-hot-toast"

const CONTROLLER_NAME = "company"

export const companyService = {
  async getAll(token: string) {
    const response = await api.get(`/${CONTROLLER_NAME}/getall`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
    if (!response.data.success) {
      toast.error("An unexpected error occured.");
    }
    return response
  }
}