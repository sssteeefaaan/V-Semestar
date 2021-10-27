
function createUser(id) {
  let userId = id;
  
  return {
    getId: () => userId,
    setId: (newId) => {
      userId = newId;
    }
  }
}

const user1 = createUser(100);
const user2 = createUser(102);
user1.setId(105);
console.log(user1.getId());