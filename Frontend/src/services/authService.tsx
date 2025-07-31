import { api } from "./api";
import { toast } from "react-hot-toast";

const CONTROLLER_NAME = "auth";

export const authService = {
    async login(email: string, password: string) {
        const response = await api.post(`/${CONTROLLER_NAME}/login`, {
            email,
            password,
        })
        if (!response.data.success) {
            toast.error("An unexpected error occured.");
        }
        return response
    },
    async register(data: any) {
        const response = await api.post(`/${CONTROLLER_NAME}/register`, data)
        if (!response.data.success) {
            toast.error("An unexpected error occured.");
        }
        return response
    }
}