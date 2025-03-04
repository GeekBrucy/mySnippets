import axios from "axios";

const clientId = process.env.REACT_APP_JOBADDER_CLIENT_ID;
const redirectUri = process.env.REACT_APP_JOBADDER_REDIRECT_URI;
const backendUrl = process.env.REACT_APP_BACKEND_URL;
const clientSecret = "";
interface Tokens {
  access_token: string;
  id_token: string;
  refresh_token: string;
}

export const initiateLogin = () => {
  const authUrl = `https://id.jobadder.com/connect/authorize?client_id=${clientId}&response_type=code&redirect_uri=${redirectUri}&scope=read write write_note write_candidate_note`;
  window.location.href = authUrl; // Redirect to JobAdder's authorization endpoint
};

export const handleCallback = async (code: string): Promise<Tokens> => {
  try {
    const response = await axios.post(`${backendUrl}/auth/callback`, { code });
    console.log(response);
    
    return response.data.tokens; // Returns access_token, id_token, refresh_token
  } catch (error) {
    console.error('Error exchanging code for tokens:', error);
    throw error;
  }
};

export const getProtectedResource = async (accessToken: string) => {
  try {
    const response = await axios.get(`${backendUrl}/ja_user`, {
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching protected resource:', error);
    throw error;
  }
};