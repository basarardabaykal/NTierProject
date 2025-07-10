import { useState } from "react"
export default function GetUser() {
  //const [name, setName] = useState("")
  const [id, setId] = useState("")
  const handleSubmit = () => {
    console.log(id)
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