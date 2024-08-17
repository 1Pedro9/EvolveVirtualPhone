CREATE TABLE messages(
    message_id INT NOT NULL AUTO_INCREMENT,
 	member_id INT NOT NULL,
    message VARCHAR(255) NOT NULL,
    date_of_message DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(message_id),
    FOREIGN KEY(member_id) REFERENCES members(member_id)
)