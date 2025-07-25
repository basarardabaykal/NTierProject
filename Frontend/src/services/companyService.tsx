import { api } from "./api";
export const companyService = {
  async getAll(token: string) {
    const response = await api.get("company/getall", {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
    return response
  }
}