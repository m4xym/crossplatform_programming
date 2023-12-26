import { Routes, Route } from "react-router-dom";
import Lab1Component from "./pages/Lab1Component";
import Lab2Component from "./pages/Lab2Component";
import Lab3Component from "./pages/Lab3Component";
import { CallbackPage } from "./pages/CallbackPage";
import Homepage from "./pages/Homepage";
import AuthenticationGuard from "./components/AuthenticationGuard";

function App() {
  return (
    <main>
      <Routes>
        <Route path="/" element={<Homepage />} />
        <Route path="/callback" element={<CallbackPage />} />
        <Route
          path="/lab1"
          element={<AuthenticationGuard component={Lab1Component} />}
        />
        <Route
          path="/lab2"
          element={<AuthenticationGuard component={Lab2Component} />}
        />
        <Route
          path="/lab3"
          element={<AuthenticationGuard component={Lab3Component} />}
        />
      </Routes>
    </main>
  );
}

export default App;
