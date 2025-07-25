import { api } from "./api"

export const userService = {
  async getAll(token: string) {
    const response = await api.get("/home/getall", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    return response.data
  },
}