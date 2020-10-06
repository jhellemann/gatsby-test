import React from "react"
import { Link } from "gatsby"
import Layout from "../components/layout"
import { useQuery, gql } from "@apollo/client"

const StarWarsPage = () => {
  const QUERY = gql`
    query getCharacters {
      characters {
        name
        friends {
          name
        }
        appearsIn
      }
    }
  `

  const { loading, error, data } = useQuery(QUERY)

  return (
    <Layout>
      <h2>Star Wars characters</h2>
      {loading && <p>Loading...</p>}
      {error && <p>Error :(</p>}
      <ul>
        {data &&
          data.characters.map(character => (
            <li>
              <strong>{character.name}</strong> <br />
              <span>appears in: {character.appearsIn.join(", ")}</span> <br />
              <span>
                friends: {character.friends.map(friend => friend.name + ", ")}
              </span>{" "}
              <br />
            </li>
          ))}
      </ul>
      <Link to="/">Back to home</Link>
    </Layout>
  )
}

export default StarWarsPage
