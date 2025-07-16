import { jwtDecode } from "jwt-decode";

export default function HomePage() {
    const handleClick = async () => {
        const token = localStorage.getItem("token");
        const response = await fetch('https://localhost:7297/api/home/get', {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        console.log(response);
    }
    return (
        <>
            <div className="m-4">
                <button onClick={handleClick}>Click me</button>
            </div>
        </>
    )
}