<%@language="VBscript" %>
<%
if Request("uName")<>"" and Request("score")<>"" then
    dim user, score
    user=request("uName")
    score=Request("score")

    Dim objStream, strData, contentArr

    Set objStream = CreateObject("ADODB.Stream")
    objStream.CharSet = "utf-8"
    objStream.Open
    objStream.LoadFromFile(server.MapPath("scripts/users.js"))
    strData = objStream.ReadText()
    contentArr=split(strData, ";")
    if err.number<>0 then
        response.write "error1"
        objStream.close
        set objStream=nothing
        response.End
    end if
    for i=0 to ubound(contentArr)-1
        if instr(contentArr(i), request("uName")) >0 then
            contentArr(i)="users[" & i-1 & "]={'uName':'" & user &"', 'score':"& score &"}"
        end if
    next
    objStream.close
    set objStream=nothing
    Set objStream = CreateObject("ADODB.Stream")
    objStream.CharSet = "utf-8"
    objStream.Open
    if err.number<>0 then
        response.write "error1"
        objStream.close
        set objStream=nothing
        response.End
    end if
    strData=""
    for i=0 to ubound(contentArr)-1
        strData=strData & contentArr(i) & ";" & vbCrLf
    next
    objStream.WriteText strData
    objStream.SaveToFile server.MapPath("scripts/users.js"), 2
    if err.number<>0 then
        response.write "error1"
        objStream.close
        set objStream=nothing
        response.End
    end if
    response.Write "sucsess"
    objStream.close
    set objStream=nothing
else
    response.Write "error1"
end if
 %>