import { api } from "./api";

export const authService = {
    async login(email: string, password: string) {
        const response = await api.post("/auth/login", {
            email,
            password,
        })
        return response
    },
    async register(data: any) {
        const response = await api.post("/auth/register", data)
        return response
    }
}