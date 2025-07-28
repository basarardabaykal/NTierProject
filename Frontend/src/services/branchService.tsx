import { api } from "./api";

const CONTROLLER_NAME = "branch";

export const branchService = {
    async getAll(token: string) {
        const response = await api.get(`/${CONTROLLER_NAME}/getall`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        return response;
    }
}