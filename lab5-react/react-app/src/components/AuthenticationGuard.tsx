import { FC, ReactElement, ComponentType } from "react";
import { withAuthenticationRequired } from "@auth0/auth0-react";

interface AuthenticationGuardProps {
  component: ComponentType<any>;
}

const AuthenticationGuard: FC<AuthenticationGuardProps> = ({
  component,
}): ReactElement => {
  const Comp = withAuthenticationRequired(component, {
    onRedirecting: () => (
      <div>
        <p>Loading...</p>
      </div>
    ),
  });

  return <Comp />;
};

export default AuthenticationGuard;
