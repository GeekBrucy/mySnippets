import React, { useEffect, useRef, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom"
import { handleCallback } from "../services/auth";

const Callback: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);
  const isTokenExchangeInitiated = useRef(false);

  useEffect(() => {
    const queryParams = new URLSearchParams(location.search);
    const code = queryParams.get('code');

    if (code && !isTokenExchangeInitiated.current) {
      console.log('callback useEffect');
      isTokenExchangeInitiated.current = true;
      handleCallback(code)
        .then((tokens) => {
          console.log(tokens);
          if (tokens) {
            localStorage.setItem('tokens', JSON.stringify(tokens));
          }
          navigate('/');
        })
        .catch((err) => {
          setError(err.message);
        });
    } else if (!code) {
      setError('Non authorization code found');
    }
  }, [location, navigate]);

  return (
    <div>
      {error ? (
        <p>Error: {error}</p>
      ) : (
        <p>Logging in...</p>
      )}
    </div>
  );
}

export default Callback;