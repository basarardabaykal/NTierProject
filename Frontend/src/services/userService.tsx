import { api } from "./api"

const CONTROLLER_NAME = "home"

export const userService = {
  async getAll(token: string) {
    const response = await api.get(`/${CONTROLLER_NAME}/getall`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    return response
  },

  async updateCompany(token: string, userId: string, companyId: string) {
    const response = await api.patch(`/${CONTROLLER_NAME}/updatecompany`, {
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