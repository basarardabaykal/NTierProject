import { useState } from "react";
import axios from "axios"
import { useNavigate } from "react-router-dom";

export default function Login() {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async () => {
    try {
      const response = await axios.post("https://localhost:7297/api/auth/login", {
        email: email,
        password: password,
      })
      console.log(response.data)
      if (response.data.success) {
        localStorage.setItem("token", response.data.data.token)
        localStorage.setItem("user", JSON.stringify(response.data.data.userDTO))
        console.log("Successfully logged in.")
        console.log("User roles:", response.data.data.userDTO.roles)
        navigate("/")
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
        <button onClick={handleSubmit}>Sign in</button>
      </div>
    </>
  )
}
