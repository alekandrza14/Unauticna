-- defines a Jump function
function Build (patrn)

        vec3.Add(0)
        vec3.Add(30)
        vec3.Add(0)
	if patrn == 3 then
		vec3.Add(0)
        	vec3.Add(30)
        	vec3.Add(0)
	end

return vec3;
end


function Item (patrn)


ditem.Add("MiniHole");
   	if patrn == 3 then
		ditem.Add("UltraHole");
	end



return ditem;
end