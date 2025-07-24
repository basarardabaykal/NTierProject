import { useState } from "react";
import { useAuth } from "../context/AuthContext";
import axios from "axios"
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "../components/ui/card"
import { Button } from "../components/ui/button"
import { Input } from "../components/ui/input"
import { Label } from "../components/ui/label"
import { Link, useNavigate } from "react-router-dom";
import { set, z } from "zod"

const signupSchema = z.object({
  firstName: z.string("Invalid name"),
  lastName: z.string("Invalid name"),
  tcNumber: z.string()
    .regex(/^[1-9][0-9]{10}$/, "Invalid TC number"),
  email: z.email("Invalid email"),
  password: z.string().min(6, "Password must have at least 6 characters"),
  confirmedPassword: z.string(),
}).refine((data) => data.password === data.confirmedPassword, {
  message: "Passwords do not match",
  path: ["confirmedPassword"],
})

export default function Signup() {
  const { login } = useAuth()
  const navigate = useNavigate()
  const [firstName, setFirstName] = useState("")
  const [lastName, setLastName] = useState("")
  const [tcNumber, setTcNumber] = useState("")
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const [confirmPassword, setConfirmPassword] = useState("")
  const [errorMessage, setErrorMessage] = useState("")
  const [isError, setIsError] = useState<boolean>(false)

  const handleSubmit = async () => {
    setErrorMessage("")
    setIsError(false);

    const validation = signupSchema.safeParse({ firstName, lastName, tcNumber, email, password, confirmedPassword: confirmPassword, })
    console.log({
      firstName,
      lastName,
      tcNumber,
      email,
      password,
      confirmedPassword: confirmPassword,
    })
    if (!validation.success) {
      const issues = validation.error.issues
      const firstError = issues[0]?.message || "Invalid input"
      setErrorMessage(firstError)
      setIsError(true)
      return
    }

    try {
      const response = await axios.post("https://localhost:7297/api/auth/register", {
        email: email,
        password: password,
        confirmPassword: confirmPassword,
        tcNumber: tcNumber,
        firstName: firstName,
        lastName: lastName,
      }, {
        headers: {
          "Content-Type": "application/json",
        }
      })
      if (response.data.success) {
        login(response.data.data.token, response.data.data.userDTO)
        window.dispatchEvent(new Event("storage"))
        setIsError(false)
        setErrorMessage("Successfully signed up, you will be redirected shortly")
        await new Promise((resolve) => setTimeout(resolve, 2000));
        navigate("/")
      }
      else {
        setErrorMessage("Signing up failed")
        setIsError(true)
      }
    } catch (error: any) {
      if (axios.isAxiosError(error)) {
        setErrorMessage(error.response?.data?.message || error.message)
      } else if (error instanceof Error) {
        setErrorMessage(error.message)
      } else {
        setErrorMessage("An unknown error occurred")
      }
      setIsError(true)
    }
  }
  return (
    <>
      <Card className="w-3/4 max-w-sm m-auto">
        <CardHeader>
          <CardTitle>Create a new account</CardTitle>
          <CardDescription>
            Fill in your credentials to create a new account
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form>
            <div className="flex flex-col gap-6">
              <div className="grid gap-2">
                <Label htmlFor="firstName">First Name</Label>
                <Input
                  id="firstName"
                  type="text"
                  required
                  value={firstName}
                  onChange={(e) => (setFirstName(e.target.value))}
                />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="lastName">Last Name</Label>
                <Input
                  id="lastName"
                  type="text"
                  required
                  value={lastName}
                  onChange={(e) => (setLastName(e.target.value))}
                />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="tcNumber">TC Number</Label>
                <Input
                  id="tcNumber"
                  type="text"
                  required
                  value={tcNumber}
                  onChange={(e) => (setTcNumber(e.target.value))}
                />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="email">Email</Label>
                <Input
                  id="email"
                  type="email"
                  required
                  value={email}
                  onChange={(e) => (setEmail(e.target.value))}
                />
              </div>
              <div className="grid gap-2">
                <div className="flex items-center">
                  <Label htmlFor="password">Password</Label>
                </div>
                <Input id="password" type="password" required
                  value={password} onChange={(e) => (setPassword(e.target.value))} />
              </div>
              <div className="grid gap-2">
                <div className="flex items-center">
                  <Label htmlFor="confirmPassword">Confirm Password</Label>
                </div>
                <Input id="confirmPassword" type="password" required
                  value={confirmPassword} onChange={(e) => (setConfirmPassword(e.target.value))} />
              </div>
            </div>
          </form>
        </CardContent>
        <CardFooter>
          {isError ? <p className="text-red-500">{errorMessage}</p> : <p className="text-green-500">{errorMessage}</p>}
        </CardFooter>
        <CardFooter className="flex-col gap-2">
          <Button type="submit" onClick={handleSubmit} className="w-full">
            Sign up
          </Button>
        </CardFooter>
        <CardFooter className="flex justify-center">
          <CardAction className="flex justify-center items-center">
            <Button variant="link"><Link to={"/login"}>Login</Link> </Button>
          </CardAction>
        </CardFooter>
      </Card>
    </>
  )
}