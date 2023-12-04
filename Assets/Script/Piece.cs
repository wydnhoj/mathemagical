using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool isWhite;
    public bool isKing;
    
    public bool isForceToMove(Piece[,] board, int x, int y){        //FIX THE JUMPING BACKWARDS OF THE KING (UPDATE ALREADY FIXED!!)
        if(isWhite || isKing){
            //top left
            if(x>=2 && y<=5){
                Piece p = board[x-1,y+1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x-2,y+2]==null){
                        return true;
                    }
                }
            }
            //eat backwards - top left
            if(x>=2 && y<=5){
                Piece p = board[x-1,y+1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x-2,y-2]==null){
                        return true;
                    }
                }
            }

            //top right
            if(x<=5 && y<=5){
                Piece p = board[x+1,y+1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x+2,y+2]==null){
                        return true;
                    }
                }
            }
            //eat backwards - top right
            if(x<=5 && y<=5){
                Piece p = board[x+1,y+1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x+2,y-2]==null){
                        return true;
                    }
                }
            }

            //top left king
            if(isKing){
                if(x>=2 && y<=5){
                    Piece p = board[x-1,y+1];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x-2,y-2]==null){
                            return true;
                        }
                    }
                }
                //eat backwards 
                if(x>=2 && y<=5){
                    Piece p = board[x-1,y+1];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x-2,y+2]==null){
                            return true;
                        }
                    }
                }

                //top right king
                if(x>=2 && y<=5){
                    Piece p = board[x+2,y-2];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x+2,y-2]==null){
                            return true;
                        }
                    }
                }
                //eat bw - top right king
                if(x<=5 && y<=5){
                    Piece p = board[x+2,y-2];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x+2,y+2]==null){
                            return true;
                        }
                    }
                }
            }

        }
        if(!isWhite || isKing){
            //bottom left
            if(x>=2 && y>=2){
                Piece p = board[x-1,y-1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x-2,y-2]==null){
                        return true;
                    }
                }
            }
            //eat bw - bottom left
            if(x>=2 && y>=2){
                Piece p = board[x-1,y-1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x-2,y+2]==null){
                        return true;
                    }
                }
            }

            //bottom right
            if(x<=5 && y>=2){
                Piece p = board[x+1,y-1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x+2,y-2]==null){
                        return true;
                    }
                }
            }
            //eat bw - bottom right
            if(x<=5 && y>=2){
                Piece p = board[x+1,y-1];
                //if opponent piece is present
                if(p!=null && p.isWhite!=isWhite){
                    //check if it can eat it and land on it
                    if(board[x+2,y+2]==null){
                        return true;
                    }
                }
            }

            //bottom left king
            if(isKing){
                if(x>=2 && y>=2){
                    Piece p = board[x-1,y-1];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x-2,y+2]==null){
                            return true;
                        }
                    }
                }
                //eat bw - bottom left king
                if(x>=2 && y>=2){
                    Piece p = board[x+2,y-2];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x+2,y-2]==null){
                            return true;
                        }
                    }
                }
                //bottom right king
                if(x<=5 && y>=2){
                    Piece p = board[x+1,y-1];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x+2,y+2]==null){
                            return true;
                        }
                    }
                }
                //eat bw - bottom right king
                if(x>=2 && y>=2){
                    Piece p = board[x+1,y-1];
                    if(p!=null && p.isWhite!=isWhite){
                        if(board[x+2,y-2]==null){
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    //make look for the possible move on the pieces and if it isKing it can move backwards
    public bool ValidMove(Piece[,] board, int x1, int y1, int x2, int y2){
        //if you are moving on top of another piece
        if(board[x2,y2] != null){
            return false;
        }

        int deltaMove = Mathf.Abs(x1-x2);
        int deltaMoveY = y2-y1;

        if(isWhite){
            if(deltaMove == 1){
                if(deltaMoveY == 1){
                    return true;
                }
            }
            else if(deltaMove == 2){
                if(deltaMoveY == 2){
                    Piece p = board[(x1+x2)/2, (y1+y2)/2];
                    if(p != null && p.isWhite != isWhite){
                        return true;
                    }
                }
                else if(deltaMoveY == -2){
                    Piece p = board[(x1+x2)/2, (y1+y2)/2];
                    if(p != null && p.isWhite != isWhite){
                        return true;
                    }
                }
            }
           
            if(isKing){
                if(deltaMove == 1){
                    if(deltaMoveY == -1){
                        return true;
                    }
                }
                else if(deltaMove == 2){
                    if(deltaMoveY == -2){
                        Piece p = board[(x1+x2)/2, (y1+y2)/2];
                        if(p != null && p.isWhite != isWhite){
                            return true;
                        }
                    }
                }
            }
        }

        if(!isWhite){
            if(deltaMove == 1){
                if(deltaMoveY == -1){
                    return true;
                }
            }
            else if(deltaMove == 2){
                if(deltaMoveY == -2){
                    Piece p = board[(x1+x2)/2, (y1+y2)/2];
                    if(p != null && p.isWhite != isWhite){
                        return true;
                    }
                }
                else if(deltaMoveY == 2){
                    Piece p = board[(x1+x2)/2, (y1+y2)/2];
                    if(p != null && p.isWhite != isWhite){
                        return true;
                    }
                }
            }
            
            if(isKing){
                if(deltaMove == 1){
                    if(deltaMoveY == 1){
                        return true;
                    }
                }
                else if(deltaMove == 2){
                    if(deltaMoveY == 2){
                        Piece p = board[(x1+x2)/2, (y1+y2)/2];
                        if(p!= null && p.isWhite != isWhite){
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
