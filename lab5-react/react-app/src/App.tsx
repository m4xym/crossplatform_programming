import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Profile from './pages/Profile';

function App() {
  return (
    <BrowserRouter>
      <main>
        <Routes>
          <Route path="/" element={<Profile />} />
        </Routes>
      </main>
    </BrowserRouter>
  )
}

export default App
