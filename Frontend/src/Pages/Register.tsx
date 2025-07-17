import { useState } from "react";
import axios from "axios"

export default function Register() {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const [confirmPassword, setConfirmPassword] = useState("")
  const [tcNumber, setTcNumber] = useState("")
  const [firstName, setFirstName] = useState("")
  const [lastName, setLastName] = useState("")

  const handleSubmit = async () => {
    try {
      console.log({ email, password, confirmPassword, tcNumber, firstName, lastName });

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
      console.log(response.data)
      if (response.data.success) {
        localStorage.setItem("token", response.data.data.token)
        console.log("Successfully registered.")
      }
    } catch (error: any) {
      console.log(error)
    }
  }
  return (
    <>
      <div>
        <div>
          <div>
            <p>Email</p>
            <input
              className="bg-white text-black  mb-4"
              type="email"
              value={email}
              onChange={(e) => (setEmail(e.target.value))}
            />
          </div>
          <div>
            <p>Password</p>
            <input
              className="bg-white text-black mb-4"
              type="password"
              value={password}
              onChange={(e) => (setPassword(e.target.value))}
            />
          </div>
          <div>
            <p>Confirm password</p>
            <input
              className="bg-white text-black  mb-4"
              type="password"
              value={confirmPassword}
              onChange={(e) => (setConfirmPassword(e.target.value))}
            />
          </div>
          <div>
            <p>Tc Number</p>
            <input
              className="bg-white text-black  mb-4"
              type="text"
              value={tcNumber}
              onChange={(e) => (setTcNumber(e.target.value))}
            />
          </div>
          <div>
            <p>First Name</p>
            <input
              className="bg-white text-black  mb-4"
              type="text"
              value={firstName}
              onChange={(e) => (setFirstName(e.target.value))}
            />
          </div>
          <div>
            <p>Last Name</p>
            <input
              className="bg-white text-black  mb-4"
              type="text"
              value={lastName}
              onChange={(e) => (setLastName(e.target.value))}
            />
          </div>
        </div>
        <button onClick={handleSubmit}>Sign Up</button>
      </div>
    </>
  )
}