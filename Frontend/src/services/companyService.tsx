import { api } from "./api";

const CONTROLLER_NAME = "company"

export const companyService = {
  async getAll(token: string) {
    const response = await api.get(`/${CONTROLLER_NAME}/getall`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
    return response
  }
}