import { useState } from "react"
import axios from "axios"

export default function GetUser() {
  //const [name, setName] = useState("")
  const [id, setId] = useState("")
  const handleSubmit = async () => {
    try {
      const response = await axios.get(" https://localhost:7297/api/Home/" + id)
      console.log(response.data)
    } catch (error) {
      console.log("An error occured.")
    }


  }
  return (
    <>
      <div>
        <input className="bg-green-500 text-blue-600" type="text" value={id} onChange={(e) => setId(e.target.value)} />
        <button onClick={handleSubmit} className="hover:text-gray-300 text-white p-4 bg-blue-600 rounded-xl">Get User</button>
      </div>
    </>
  )
}