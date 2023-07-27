let _baseUrl = "";
let _headers;
let responseHandler;

export const fetchWrapper = {
  create: ({ baseUrl = "", headers }) => {
    _baseUrl = baseUrl;
    _headers = headers;

    return {
      baseUrl,
      headers,
      addResponseHandler,
      get,
      post,
    };
  },
};
const addResponseHandler = (callback) => (responseHandler = callback);

const get = async (url) => {
  return await query({
    url,
    options: { method: "GET", headers: _headers },
  });
};

const post = async (url, body) => {
  return await query({
    url,
    options: {
      method: "POST",
      headers: {
        ..._headers,
        "Content-Type": "application/json;charset=UTF-8",
      },
      body: JSON.stringify(body),
    },
  });
};

const query = async ({ url, options = {} }) => {
  const response = await fetch(_baseUrl + url, {
    ...options,
  });

  if (responseHandler) await responseHandler(response);

  return response;
};
