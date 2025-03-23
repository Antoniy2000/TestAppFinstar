import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:5227/api",
  headers: {
    "Content-type": "application/json"
  }
});