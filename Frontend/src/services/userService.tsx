import { api } from "./api"

export const userService = {
  async getAll(token: string) {
    const response = await api.get("/home/getall", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    return response
  },

  async updateCompany(token: string, userId: string, companyId: string) {
    const response = await api.patch("/home/updatecompany", {
      id: userId,
      firstname: "placeholder",
      lastname: "placeholder",
      tcnumber: "11111111111",
      email: "placeholder",
      companyId: companyId,
      roles: [
        "placeholder"
      ]
    },
      {
        headers: { Authorization: `Bearer ${token}` },
      })
    return response
  }
}