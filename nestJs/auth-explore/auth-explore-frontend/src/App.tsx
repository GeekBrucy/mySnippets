import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { getProtectedResource, initiateLogin } from './services/auth';
import { Route, BrowserRouter, Routes } from 'react-router-dom';
import Callback from './components/Callback';
import axios from 'axios';
import { Buffer } from 'buffer';
interface Tokens {
  access_token: string;
  id_token: string;
  refresh_token: string;
}
function App() {
  const [tokens, setTokens] = useState<Tokens | null>(() => {
    const storedTokens = localStorage.getItem('tokens');
    console.log(storedTokens);
    
    return storedTokens ? JSON.parse(storedTokens) : null;
  });

  const handleLogin = () => {
    initiateLogin();
  };

  const handleLogout = () => {
    localStorage.removeItem('tokens');
    setTokens(null);
  };

  const handleProtectedResource = async () => {
    if (tokens) {
      try {
        const data = await getProtectedResource(tokens.access_token);
        console.log('Protected resource:', data);
      } catch (error) {
        console.error('Failed to fetch protected resource:', error);
      }
    }
  };

  const validateToken = async () => {
    const clientId = "";
    const clientSecret = "";
    const introspectionUrl = 'https://id.jobadder.com/connect/introspect'; // JobAdder's introspection endpoint

    const params = new URLSearchParams({
      // client_id: clientId ?? '',
      // client_secret: clientSecret ?? '',
      token: tokens?.access_token ?? '',
    });
const auth = Buffer.from(`${clientId}:${clientSecret}`, "utf8").toString("base64");
    try {
      const response = await axios.post(introspectionUrl, params.toString(), {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
          'Authorization': `Basic ${auth}`
        },
        auth: {
          username: clientId!,
          password: clientSecret!
        }
      });

      return response.data; // Returns token details (e.g., active, sub, exp)
    } catch (error) {
      throw new Error('Failed to validate token');
    }
  }

  return (
    <BrowserRouter>
      <div>
        <nav>
          {tokens ? (
            <button onClick={handleLogout}>Logout</button>
          ) : (
            <button onClick={handleLogin}>Login with JobAdder</button>
          )}
          <p>
            <button onClick={handleProtectedResource}>Call protected resource</button>
          </p>
          <p>
            <button onClick={validateToken}>Validate Token</button>
          </p>
        </nav>
        <Routes>
          <Route path="/callback" element={<Callback />}></Route>
          <Route
            path="/"
            element={
              <div>
                <h1>Welcome to My App</h1>
                {tokens ? (
                  <p>You are logged in!</p>
                ) : (
                  <p>Please log in to continue.</p>
                )}
              </div>
            }
          />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
