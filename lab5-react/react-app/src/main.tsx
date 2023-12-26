import ReactDOM from "react-dom/client";
import { BrowserRouter as Router } from "react-router-dom";
import Auth0ProviderWithHistory from "./components/Auth0ProviderWithHistory.tsx";
import App from "./App.tsx";
import "./index.css";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <Router>
    <Auth0ProviderWithHistory>
      <App />
    </Auth0ProviderWithHistory>
  </Router>
);
