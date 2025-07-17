import { jwtDecode } from "jwt-decode";

export default function HomePage() {
    const handleClick1 = async () => {
        const token = localStorage.getItem("token");
        const response = await fetch('https://localhost:7297/api/home/get', {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        console.log(response);
    }
    const handleClick2 = async () => {
        const token = localStorage.getItem("token");
        const response = await fetch('https://localhost:7297/api/home/getall', {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        console.log(response);
    }
    return (
        <>
            <div className="m-4">
                <input type="" />
                <button onClick={handleClick1}>Authenticed click</button>
            </div>
            <div className="m-4">
                <input type="" />
                <button onClick={handleClick2}>Admin click</button>
            </div>
        </>
    )
}