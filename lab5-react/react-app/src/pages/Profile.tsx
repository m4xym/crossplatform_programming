import { useAuth0 } from "@auth0/auth0-react";
import LogoutButton from "../components/LogoutButton";
import LoginButton from "../components/LoginButton";
import Lab2Component from "../components/Lab2Component";
import Lab3Component from "../components/Lab3Component";
import Lab1Component from "../components/Lab1Component";

const Profile = () => {
  const { user, isAuthenticated, isLoading } = useAuth0();

  if (isLoading) {
    return <div>Loading ...</div>;
  }

  return (
    isAuthenticated && user ? (
      <div className="container bg-light">
        <div className="text-center mt-4">
          <img className="rounded-circle mt-2" src={user.picture} alt={user.name} />
          <h2 className="mt-3">{user["http://localhost:5173/full_name"]}</h2>
          <p>{user.email}</p>
          <p>{user["http://localhost:5173/phone_number"]}</p>
          <br /><br /><br />
          <LogoutButton />
          <br /><br /><br />
        </div>
        <div className="container mt-2">
          <div className="col">
            <div className="row-md-4">
              <Lab1Component />
            </div>
            <div className="row-md-4">
              <Lab2Component />
            </div>
            <div className="row-md-4">
              <Lab3Component />
            </div>
          </div>
        </div>
      </div>
    ) : <LoginButton />
  );
};

export default Profile;