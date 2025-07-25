import { useEffect, useState } from 'react';
import { useAuth } from '../context/AuthContext';

interface ProfileProps {
  isOpen: boolean;
  onClose: () => void;
}

export default function Profile({ isOpen, onClose }: ProfileProps) {
  const { user } = useAuth();
  const [isVisible, setIsVisible] = useState(false);
  const [shouldRender, setShouldRender] = useState(false);

  useEffect(() => {
    if (isOpen) {
      setShouldRender(true);
      setTimeout(() => setIsVisible(true), 10);
    } else {
      setIsVisible(false);
      setTimeout(() => setShouldRender(false), 300);
    }
  }, [isOpen]);

  if (user == null || !shouldRender) return null;

  return (
    <div className={`fixed inset-0 z-50 flex items-end justify-center pb-24 transition-all duration-300 ${isVisible ? 'opacity-100' : 'opacity-0'
      }`}>
      <div
        className={`absolute inset-0 bg-black/20 transition-opacity duration-300 ${isVisible ? 'opacity-100' : 'opacity-0'
          }`}
        onClick={onClose}
      />

      <div className={`relative w-[90%] max-w-md bg-white dark:bg-zinc-900 rounded-2xl p-6 overflow-auto max-h-[70vh] shadow-xl transition-all duration-300 ${isVisible
        ? 'opacity-100 transform translate-y-0 scale-100'
        : 'opacity-0 transform translate-y-8 scale-95'
        }`}>
        <button
          onClick={onClose}
          className="absolute top-3 right-3 text-xl font-bold hover:bg-gray-100 dark:hover:bg-zinc-800 w-8 h-8 rounded-full flex items-center justify-center transition-colors"
        >
          ×
        </button>
        <div className="flex flex-col items-center text-center">
          <h2 className="text-2xl font-semibold mt-4 mb-6">Profile Information</h2>

          <div className="w-full text-left space-y-4">
            <div>
              <p className="text-sm text-zinc-500">First Name</p>
              <p className="text-lg font-medium text-zinc-800 dark:text-white">{user?.firstName}</p>
            </div>

            <div>
              <p className="text-sm text-zinc-500">Last Name</p>
              <p className="text-lg font-medium text-zinc-800 dark:text-white">{user?.lastName}</p>
            </div>

            <div>
              <p className="text-sm text-zinc-500">Email</p>
              <p className="text-lg font-medium text-zinc-800 dark:text-white break-all">{user?.email}</p>
            </div>

            <div>
              <p className="text-sm text-zinc-500">TC Number</p>
              <p className="text-lg font-medium text-zinc-800 dark:text-white">{user?.tcnumber}</p>
            </div>

            <div>
              <p className="text-sm text-zinc-500">Roles</p>
              <p className="text-lg font-medium text-zinc-800 dark:text-white">{user?.roles?.join(", ")}</p>
            </div>
          </div>

          <button
            type="button"
            className="mt-6 w-full bg-black hover:bg-gray-900 text-white py-2 rounded flex items-center justify-center gap-2 transition-colors"
          >
            Change Password 🔒
          </button>
        </div>

      </div>
    </div>
  )
}