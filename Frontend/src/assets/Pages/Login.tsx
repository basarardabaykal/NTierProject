import { useState } from "react";
import axios from "axios"

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async () => {
    try {
      const response = await axios.post(" https://localhost:7297/api/auth/login", {
        email: email,
        password: password,
      })
      console.log(response.data)
      if (response.data.success) {
        localStorage.setItem("token", response.data.data.token)
        console.log("Successfully logged in.")
      }
    } catch (error) {
      console.log("An error occured.")
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

        </div>
        <button onClick={handleSubmit}>Sign Up</button>
      </div>
    </>
  )
}
