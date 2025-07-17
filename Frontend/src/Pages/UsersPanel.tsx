import UsersTable from "../components/UsersTable"

export default function UsersPanel() {
    const users = [
        { email: "alice@example.com", name: "Alice Smith", company: "Tech Solutions Inc." },
        { email: "bob@example.com", name: "Bob Johnson", company: "Global Innovations" },
        { email: "charlie@example.com", name: "Charlie Brown", company: "Creative Designs LLC" },
        { email: "diana@example.com", name: "Diana Prince", company: "Wonder Corp" },
        { email: "eve@example.com", name: "Eve Adams", company: "Future Systems" },
    ]

    return (
        <main className="flex min-h-screen flex-col items-center justify-center p-4">
            <h1 className="mb-6 text-3xl font-bold">User Directory</h1>
            <UsersTable users={users} />
        </main>
    )
}