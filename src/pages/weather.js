import React from "react"
import { Link } from "gatsby"
import { useQuery, gql } from "@apollo/client"
import Layout from "../components/layout"

const WeatherPage = () => {
  const WEATHER = gql`
    query getWeather {
      weather(latitude: 61.389444, longitude: 5.33) {
        date
        longitude
        latitude
        value
        unit
      }
    }
  `
  const { loading, error, data } = useQuery(WEATHER)

  return (
    <Layout>
      {loading && <p>Loading...</p>}
      {error && <p>Error :(</p>}
      {data && (
        <>
          <h2>Weather on {data.weather.date}:</h2>
          <span>
            latitude {data.weather.latitude}, longitude {data.weather.longitude}
            :{" "}
          </span>
          <strong>
            {data.weather.value} {data.weather.unit}
          </strong>
        </>
      )}
      <br />
      <br />
      <Link to="/">Back to home</Link>
    </Layout>
  )
}

export default WeatherPage
