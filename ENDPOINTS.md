# Users

**Create User**

| URL              | /api/users                                                            |
|------------------|-----------------------------------------------------------------------|
| Method           | `POST`                                                                |
| Auth Required?   | **No**          
| URL Params       | None                                                                  |
| Body Params      | `email=[string]` `password=[string]`                                  |
| Success Response | **Code:** `200` **Content:** `{ id : 3, email : "test@example.org" }` |
| Error Response   | **Code:** `400` **Content:** `{"error":"Email already in use."}`                  |

**Login**

| URL              | /api/login                                                            |
|------------------|-----------------------------------------------------------------------|
| Method           | `POST`                                                                |
| Auth Required?   | **No**          
| URL Params       | None                                                                  |
| Body Params      | `email=[string]` `password=[string]`                                  |
| Success Response | **Code:** `200` **Content:** `{ "accessToken": "...", "refreshToken": "...", "expiration": "..." }` |
| Error Response   | **Code:** `401` **Content:** `{"error":"Invalid Credentials"}`                  |

# Boards

**List Boards**

| URL              | /api/boards                                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                |
| Auth Required?   | **No**                                  |
| URL Params       | None                                                                  |
| Body Params      | None                                  |
| Success Response | **Code:** `200` **Content:** `[{"id":1,"name":"Hello World","description":"This a test board.","createdAt":"2019-06-07T15:43:12.207"}]` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}` 

**Retrieve Board**

| URL              | /api/boards/:board_id                                                       |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                |
| Auth Required?   | **No**                        |
| URL Params       | `board_id=[int]`                                                      |
| Body Params      | None                      |
| Success Response | **Code:** `200` **Content:** `{"id":1,"name":"Hello World","description":"This a test board.","createdAt":"2019-06-07T15:43:12.207"}` |
| Error Response   | **Code:** `404`              |

**Create Board**

| URL              | /api/boards                                                            |
|------------------|-----------------------------------------------------------------------|
| Method           | `POST`                                                                |
| Auth Required?   | **Yes**          
| URL Params       | None                                                                  |
| Body Params      | `name=[string]` `description=[string]`                                  |
| Success Response | **Code:** `200` **Content:** `{"id":1,"name":"Hello World","description":"This a test board.","createdAt":"2019-06-07T15:43:12.207"}` |
| Error Response   | **Code:** `401` **Content:** `{"error":"Invalid Permissions"}`            |

**Delete Board**

| URL              | /api/boards/:board_id                                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `DELETE`                                                                |
| Auth Required?   | **Yes**          |
| URL Params       | `board_id=[int]`                                                      |
| Body Params      | None |
| Success Response | **Code:** `204` |
| Error Response   | **Code:** `404` **Content:** `{"error":"Board not found"}`, **Code:** `401` **Content:** `{"error":"Invalid Permissions"}`|

**Update Board**

| URL              | /api/boards/:board_id                                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `PUT`                                                                |
| Auth Required?   | **Yes**          |
| URL Params       | `board_id=[int]`                                                      |
| Body Params      | `name=[string]` `description=[string]`                                  |
| Success Response | **Code:** `200` **Content:** `{"id":5,"name":"Updated","description":"This board is updated.","createdAt":"2019-06-07T15:43:12.207"}` |
| Error Response   | **Code:** `404` **Content:** `{"error":"Board not found"}`, **Code:** `401` **Content:** `{"error":"Invalid Permissions"}`|

# Posts

**List Posts For Board**

| URL              | /api/boards/:board_id/posts                                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                |
| Auth Required?   | **No**                                  |
| URL Params       | `board_id=[int]`                                                                  |
| Body Params      | None                                  |
| Success Response | **Code:** `200` **Content:** `[{"id":1,"title":"Hello Board","body":"This is a test post","createdAt":"2019-06-07T15:43:12.217362","board":{"id":1,"name":"Hello World","description":"This a test board.","createdAt":"2019-06-07T15:43:12.207"}}]` |
| Error Response   |    **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Retrieve Post**

| URL              | /api/posts/:post_id                                                          |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                |
| Auth Required?   | **No**                                  |
| URL Params       | `post_id=[int]`                                                                  |
| Body Params      | None                                  |
| Success Response | **Code:** `200` **Content:** `{"id":1,"title":"Hello Board","body":"This is a test post","createdAt":"2019-06-07T15:43:12.217362"}` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Create Post**

| URL              | /api/boards/:board_id/posts                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `POST`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `board_id=[int]`                                                      |
| Body Params      | `title=[string]` `body=[string]`                               |
| Success Response | **Code:** `200` **Content:** `{"id":2,"title":"Hello Board","body":"This is a test post","createdAt":"2019-06-07T15:43:12.217362"}` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Delete Post**

| URL              | /api/posts/:post_id                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `DELETE`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | None                               |
| Success Response | **Code:** `204` |
| Error Response   | **Code:** `404` **Content:** `{"error":"Post not found"}`, **Code:** `401` **Content:** `{"error":"Invalid Permissions"}`|

**Update Post**

| URL              | /api/posts/:post_id                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `PUT`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | `title=[string]` `body=[string]`                               |
| Success Response | **Code:** `200` **Content:** `{"id":2,"title":"Hello Board","body":"This is a test post","createdAt":"2019-06-07T15:43:12.217362"}` |
| Error Response   | **Code:** `404` **Content:** `{"error":"Post not found"}`, **Code:** `401` **Content:** `{"error":"Invalid Permissions"}`|


# Replies

**List Replies For Post**

| URL              | /api/posts/:post_id/replies                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                 |
| Auth Required?   | **No**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | None                               |
| Success Response | **Code:** `200` **Content:** `[{"id":1,"body":"This is a test reply","createdAt":"2019-06-07T15:43:12.221289"},{"id":2,"body":"This is another test reply","createdAt":"2019-06-07T15:43:12.221289"}]` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Retrieve Reply**

| URL              | /api/replies/:reply_id                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `GET`                                                                 |
| Auth Required?   | **No**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | None                               |
| Success Response | **Code:** `200` **Content:** `{"id":1,"body":"This is a test reply","createdAt":"2019-06-07T15:43:12.221289"}` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Create Reply**

| URL              | /api/posts/:post_id/replies                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `POST`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | `body=[string]`                               |
| Success Response | **Code:** `200` **Content:** `{"id":1,"body":"This is a test reply","createdAt":"2019-06-07T15:43:12.221289"}` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Delete Reply**

| URL              | /api/replies/:reply_id                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `DELETE`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `reply_id=[int]`                                                      |
| Body Params      | None                               |
| Success Response | **Code:** `204` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |

**Update Reply**

| URL              | /api/replies/:reply_id                                           |
|------------------|-----------------------------------------------------------------------|
| Method           | `PUT`                                                                 |
| Auth Required?   | **Yes**                                  |
| URL Params       | `post_id=[int]`                                                      |
| Body Params      | `body=[string]`                               |
| Success Response | **Code:** `200` **Content:** `{"id":1,"body":"This is an updated reply","createdAt":"2019-06-07T15:43:12.221289"}` |
| Error Response   | **Code:** `500` **Content:** `{"error":"Server Error"}`                 |



