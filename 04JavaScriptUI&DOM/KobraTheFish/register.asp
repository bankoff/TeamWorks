<%@language="VBScript" %>
<%
    on error resume next
    if request("uName") <> "" then
        Dim objStream, strData, contentArr, isTaken
        isTaken=false
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
            isTaken=true
            end if
        next
        if isTaken=true then
            response.write "error2"
        else
            strData=strData & vbCrLf & "users[" & ubound(contentArr)-1 & "]={'uName':'" & request("uName") &"', 'score':0};"
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
            objStream.WriteText strData
            objStream.SaveToFile server.MapPath("scripts/users.js"), 2
            if err.number<>0 then
                response.write "error1"
                objStream.close
                set objStream=nothing
                response.End
            end if
            response.Write "sucsess"
        end if
        objStream.close
        set objStream=nothing

    else
        response.Write "error1"
    end if
     %>