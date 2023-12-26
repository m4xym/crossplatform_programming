import { useAuth0 } from "@auth0/auth0-react";

const Profile = () => {
  const { user, isLoading } = useAuth0();

  if (isLoading) {
    return <div>Loading ...</div>;
  }

  return (
    user && (
      <div className="container bg-light">
        <div className="text-center mt-4">
          <img
            className="rounded-circle mt-2"
            src={user.picture}
            alt={user.name}
          />
          <h2 className="mt-3">{user["http://localhost:5173/full_name"]}</h2>
          <p>{user.email}</p>
          <p>{user["http://localhost:5173/phone_number"]}</p>
        </div>
      </div>
    )
  );
};

export default Profile;
